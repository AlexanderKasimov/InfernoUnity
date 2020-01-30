using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //становиться слишком большим классом - вынести графику в компонент? или выстрел?
    public GameObject muzzle;

    public Projectile projectilePrefab;
    [HideInInspector]
    public Vector2 shootDirection;

    public float damage = 1f;
    public float fireRate = 240f;

    public bool useInaccuracy = true;
    public float maxInaccuracyAngle = 5f;

    public bool useRandomPitch = true;
    public float minPitch = 0.6f;
    public float maxPitch = 0.9f;
    public float defaultPitch = 1f;

    private AudioSource audioSource;

    private float startYScale;

    public bool useMuzzleEffect = true;
    public Effect muzzleFlashEffect;

    public bool useGunKick = true;
    private bool isGunKick = false;
    private Vector3 defaultLocalPosition;
    private ZSorting zSorting;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startYScale = transform.localScale.y;
        defaultLocalPosition = transform.localPosition;
        zSorting = GetComponent<ZSorting>();
    }

    public void Fire()
    {
        //Добавить разброс
        Vector2 spreadDir = shootDirection;
        if (useInaccuracy)
        {
            float angle = Random.Range(-maxInaccuracyAngle, maxInaccuracyAngle) * Mathf.Deg2Rad;
            spreadDir.x = shootDirection.x * Mathf.Cos(angle) - shootDirection.y * Mathf.Sin(angle);
            spreadDir.y = shootDirection.x * Mathf.Sin(angle) + shootDirection.y * Mathf.Cos(angle);
        }       

        Projectile projectile = Instantiate(projectilePrefab, muzzle.transform.position, Quaternion.Euler(0, 0, 0));
        projectile.movementVector = spreadDir;
        projectile.damage = damage;

        //Play SFX
        if (useRandomPitch)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }
        else
        {
            audioSource.pitch = defaultPitch;
        }
      
        audioSource.Play();

        //Play VFX - muzzle
        if (useMuzzleEffect)
        {
            float deltaRot = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            Effect muzzleflash = Instantiate(muzzleFlashEffect, transform.position, Quaternion.Euler(0f, 0f, deltaRot));
            muzzleflash.PlayEffect((fireRate / 60f) / muzzleflash.GetAnimLength());
        }      


        //Start GunKick
        if (useGunKick && !isGunKick)
        {
            StartCoroutine("GunKick");
        }

    }

    //требуется рефактор + замена лерпа? кастомное время
    private IEnumerator GunKick()
    {
        isGunKick = true;
        float t = 0;
        Vector2 newLocalPosition = Vector2.zero;
        while (t <=  30f/fireRate)
        {
            t += Time.deltaTime;
            newLocalPosition = Vector2.Lerp(defaultLocalPosition, (Vector2)defaultLocalPosition + shootDirection * -1f * 0.1f, t / (30f / fireRate));
            transform.localPosition = new Vector3(newLocalPosition.x, newLocalPosition.y, transform.localPosition.z);          
            yield return null;
        }
        while (t < 60f/fireRate)
        {
            t += Time.deltaTime;
            newLocalPosition = Vector2.Lerp((Vector2)defaultLocalPosition + shootDirection * -1f * 0.1f, defaultLocalPosition, t / (60f / fireRate));
            transform.localPosition = new Vector3(newLocalPosition.x, newLocalPosition.y, transform.localPosition.z);
            yield return null;
        }
        transform.localPosition = new Vector3(defaultLocalPosition.x, defaultLocalPosition.y, transform.localPosition.z);  
        isGunKick = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);

        shootDirection = (mousePosition - objectPosition).normalized;

        float deltaRot = Mathf.Atan2(mousePosition.y - objectPosition.y, mousePosition.x - objectPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, deltaRot);

        //Orient to crosshair
        float weaponRotation = transform.rotation.eulerAngles.z;
        if (weaponRotation > 90 && weaponRotation < 270)
        {            
            transform.localScale = new Vector3(transform.localScale.x, -startYScale, transform.localScale.z);           
        }
        else
        {            
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);            
        }
    }
}
