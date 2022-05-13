using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour

{
    Vector3 myVector;
    public static DamagePopUp Create(Vector3 position, int damageAmount)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.PopUpDamage, position, Quaternion.identity);
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damageAmount);

        return damagePopUp;
    }
    private TextMeshPro textMesh;
    // Start is called before the first frame update

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();

    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }
    public void  Start()
    {
          
    }
    private void Update()
    {
        float moveYSpeed = 10f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        //transform.position += new Vector3(0, 100);
    }
}
