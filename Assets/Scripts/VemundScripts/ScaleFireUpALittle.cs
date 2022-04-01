using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFireUpALittle : MonoBehaviour
{

    public bool IsDoneScalingP1 = false;
    public bool IsDoneScalingP2 = true;

    private float RndNumberForBonusScaling;

    public float ScalingP1Time = 3.3f;
    public float ScalingP2Time = 30f;

    private void Awake()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetScalingInactiveAfterTime());

        RndNumberForBonusScaling = Random.Range(0.0015f, 0.0025f);
    }

    // Update is called once per frame
    void Update()
    {
        //Scales the flame quickly up to standard big flame size
        if (IsDoneScalingP1 == false)
        {
            transform.localScale = transform.localScale + new Vector3(0.009f, 0.009f, 0.009f) * Time.deltaTime;
        }

        //Scales the flame slowly over time and in size based on a random number just to give the fire some realism
        if (IsDoneScalingP2 == false)
        {
            transform.localScale = transform.localScale + new Vector3(RndNumberForBonusScaling, RndNumberForBonusScaling, RndNumberForBonusScaling) * Time.deltaTime;
        }

    }

    IEnumerator SetScalingInactiveAfterTime()
    {
        yield return new WaitForSeconds(ScalingP1Time);

        IsDoneScalingP1 = true;
        IsDoneScalingP2 = false;

        Debug.Log("SmallFireWillGrow");
        yield return new WaitForSeconds(ScalingP2Time);


        IsDoneScalingP2 = true;

    }
}
