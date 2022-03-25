using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnCollisionSpawnFire : MonoBehaviour
{
    public GameObject FireUnit;
    public GameObject BigFireUnit;

    public GameObject NonGrownFireUnit;

    public Transform SpawnPointL;
    public Transform SpawnPointR;
    public GameObject FireUnitPrefab;

    public float FireSpreadAfterSeconds;

    private Rigidbody2D rb;

    public GameObject FullFireCountR;
    public GameObject FullFireCountL;

    public GameObject LightForLonelyFire;

    public GameObject LeftFire;
    public GameObject RightFire;

    public float RndNumberForFireLifetime;
    public float RndNumberForFireSpawn;

    public bool FireShouldSpawnL = false;
    public bool FireShouldSpawnR = false;
    public bool FireIsSmall = false;

    public bool FireJustSpawnedL = false;
    public bool FireJustSpawnedR = false;

    public bool CollisionOnStartCheckIsHappening = false;
    public bool IsNotYetGrounded = true;

    public bool BoolWasCheckedOneSecondAgoR = false;
    public bool BoolWasCheckedOneSecondAgoL = false;



    private void Awake()
    {
        BigFireUnit.SetActive(false);

        // passe på at unit starter med riktig bool 
        IsNotYetGrounded = true;
        // passer på at flammen ikke roterer
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // passer på at invisible objektet spawner uten aktiv flamme og at dem faller
        FireUnit.SetActive(false);
        rb.gravityScale = 0.5f;
        Debug.Log("FireObjectHasGravity");
    }

    private void Start()
    {
        

        StartCoroutine(SetAfterTime2());

        StartCoroutine(IsUnitCollidingAtSpawn(0f));

    }

    IEnumerator IsUnitCollidingAtSpawn(float time)
    {
        // Skjekker om objektet faller i første frames
        yield return new WaitForSeconds(time);

        CollisionOnStartCheckIsHappening = true;


        yield return new WaitForSeconds(0.3f);

        CollisionOnStartCheckIsHappening = false;

        // If it falls too far - Destroy
        yield return new WaitForSeconds(0.6f);

        if (IsNotYetGrounded == true)
        {
            Debug.Log("Fire was not allowed to spawn because it didn't find any ground in time");
            Destroy(gameObject);
        }

    }

    IEnumerator SetAfterTime2()
    {
        // random death time for flammer for å minske mekanisk feel
        RndNumberForFireLifetime = Random.Range(45, 80);

        yield return new WaitForSeconds(RndNumberForFireLifetime);

        // pre death, tanken er å bruke exit trigger for å registrere at en ny flamme kan bli født
        FireUnit.SetActive(false);
        //rb.gravityScale = -2;

        yield return new WaitForSeconds(1);

        // FireLifetime is over
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Skjekker om pre-spawn unit har falt en acceptable lengde eller om den colliderer med en gang (feks inni et objekt)
        if (CollisionOnStartCheckIsHappening == true)
        {
            Debug.Log("Fire Was Not Allowed To Spawn due to super early collision");
            Destroy(gameObject);
        }

        Debug.Log("FireUnitIsSpawning on collision place");

        rb.gravityScale = 0;
        Debug.Log("FireObjectHas zero Gravity");
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        // sørger for at objektet står i ro, men faller vertikalt

        // Registerer at unit har landet på noe
        IsNotYetGrounded = false;

        // These are actually not true but it has to be put true once to activate
        BoolWasCheckedOneSecondAgoL = true;
        BoolWasCheckedOneSecondAgoR = true;

        // SpawnFireAfterLanded
        StartCoroutine(SetAfterTime3());




        if (FullFireCountL.activeInHierarchy == false)
        {
            FireShouldSpawnL = true;

            // Wait for seconds to spawn new fire-unit 
            StartCoroutine(SetAfterTimeR());


        }

        if (FullFireCountR.activeInHierarchy == false)
        {
            FireShouldSpawnR = true;

            // Wait for seconds to spawn new fire-unit 
            StartCoroutine(SetAfterTimeL());


        }

    }

    IEnumerator SetAfterTime3()
    {
        // random spawntime for fire
        RndNumberForFireSpawn = Random.Range(0.4f, 0.59f);

        yield return new WaitForSeconds(RndNumberForFireSpawn);

        // spawns fire on collision med ground
        FireUnit.SetActive(true);
        FireIsSmall = true;

    }

    IEnumerator SetAfterTimeR()
    {
        FireShouldSpawnL = false;

        yield return new WaitForSeconds(FireSpreadAfterSeconds);

        // L flamme spawn
        if (FireJustSpawnedL == false && FullFireCountL.activeInHierarchy == false)
        {


            Instantiate(FireUnitPrefab, SpawnPointL.position, SpawnPointL.rotation);
            FireJustSpawnedL = true;
            FireShouldSpawnL = false;

            yield return new WaitForSeconds(4f);

            FireJustSpawnedL = false;


        }
    }

    IEnumerator SetAfterTimeL()
    {
        FireShouldSpawnR = false;

        yield return new WaitForSeconds(FireSpreadAfterSeconds);

        // R flamme spawn
        if (FireJustSpawnedR == false && FullFireCountR.activeInHierarchy == false)
        {
            Instantiate(FireUnitPrefab, SpawnPointR.position, SpawnPointR.rotation);
            FireJustSpawnedR = true;
            FireShouldSpawnR = false;

            yield return new WaitForSeconds(4f);

            FireJustSpawnedR = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void Update()
    {
        if (FullFireCountL.activeInHierarchy == true && FullFireCountR.activeInHierarchy == true)
        {
            // om det er flamme på begge sider av en flamme, erstattes flamme sprite med større flammesprite

            if (FireIsSmall == true)
            {

                StartCoroutine(SetAfterTimeBigFire(1.5f));
                FireIsSmall = false;
            }


        }

        //If smol fire is all alone, it emits ight, this occurs only on the mother flame
        if (FullFireCountL.activeInHierarchy == false && FullFireCountR.activeInHierarchy == false)
        {
            LightForLonelyFire.SetActive(true);
        }

        /*
        // fjerner liten flamme slik at den ikke overlapper med annen liten flamme
        if (FullFireCountL.activeInHierarchy)
        {


            if (BigFireUnit.activeInHierarchy == true)
            {
                LeftFire.SetActive(false);
                
            }
        }
        
        if (FullFireCountR.activeInHierarchy == true)
        {

            if (FireIsSmall == true)
            {

                RightFire.SetActive(false);
            }
        }
        */

        if (FullFireCountL.activeInHierarchy == false && FireShouldSpawnL == true)
        {
            if (FireShouldSpawnL == true)
            {
                // L flamme spawn
                StartCoroutine(SetAfterTimeR());
                //FireShouldSpawnL = false;
            }
        }

        if (FullFireCountR.activeInHierarchy == false && FireShouldSpawnR == true)
        {
            if (FireShouldSpawnR == true)
            {
                // R flamme spawn
                StartCoroutine(SetAfterTimeL());
                //FireShouldSpawnR = false;
            }
        }


        if (FullFireCountL.activeInHierarchy == false)
        {

           

            if (BoolWasCheckedOneSecondAgoL == true)
            {
                BoolWasCheckedOneSecondAgoL = false;

                Debug.Log("CheckingLeftSpace");
                //Check Once Every 4 Second

                StartCoroutine(CheckIfNewFireCanBeSpawnedL(0));
            }
            

        }

        if (FullFireCountR.activeInHierarchy == false)
        {

            if (BoolWasCheckedOneSecondAgoR == true)
            {
                BoolWasCheckedOneSecondAgoR = false;

                Debug.Log("CheckingRightSpace");
                //Check Once Every 4 Second

                StartCoroutine(CheckIfNewFireCanBeSpawnedR(0));
            }

        }

    }

    private IEnumerator CheckIfNewFireCanBeSpawnedL(float time)
    {
        BoolWasCheckedOneSecondAgoL = false;
        FireShouldSpawnL = true;
        yield return new WaitForSeconds(3);
        BoolWasCheckedOneSecondAgoL = true;
    }

    private IEnumerator CheckIfNewFireCanBeSpawnedR(float time)
    {
        BoolWasCheckedOneSecondAgoR = false;
        FireShouldSpawnR = true;
        yield return new WaitForSeconds(3);
        BoolWasCheckedOneSecondAgoR = true;
    }

    IEnumerator SetAfterTimeBigFire(float time)
    {
        yield return new WaitForSeconds(time);

        FireUnit.SetActive(false);

        BigFireUnit.SetActive(true);

        Debug.Log("SmallFireWillGrow");
        yield return new WaitForSeconds(1f);




    }



}



  

