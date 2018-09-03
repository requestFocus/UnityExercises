using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLerping : MonoBehaviour
{
    public Transform Target;

    private const float _timeDuration = 1;
    private float _timeFraction = 0;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private Vector3 _relativePosition;

    private Quaternion _startRotation;
    private Quaternion _endRotation;
    private Quaternion _targetRotation;

    private void Start()
    {
        //==== obrot o 50st, a jesli to wiecej niż aktualna roznica miedzy obiektami to dostraja do Target.rotation
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Target.rotation, 50);

        _startPosition = transform.position;
        _endPosition = Target.transform.position;

        _startRotation = transform.rotation;
        _endRotation = Target.transform.rotation;

        _relativePosition = transform.position - Target.transform.position;

        //==== tworzy quaternion wg wektora _relativePosition i opcjonalnego wskazania kierunku dla osi Y (czyli UP), można wskazać, by rotacja wskazywała na rotację targetu!
        //_targetRotation = Quaternion.LookRotation(_relativePosition, Target.transform.up);

        //==== jeden raz obraca transform wokół osi z.back wzgledem punktu -2, 0, 0 o 36st
        //transform.RotateAround(new Vector3(-2, 0, 0), Vector3.back, 36);

        //==== przestawia rotację obiektu biorąc orientacje Vector3.right i ustawiając ją na transform.forward (dobrze to widać na Scenie/Local)
        //transform.rotation = Quaternion.FromToRotation(Vector3.right, transform.forward);       
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _timeFraction * 0.5f);

        //==== liniowa interpolacja od rotacji Start do Target po czasie timeFraction (0 ... 1)
        //transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, _timeFraction * 0.5f);

        //==== liniowa interpolacja od rotacji Start do Quaternion.LookRotation po czasie timeFraction (0 ... 1)
        //transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, _timeFraction * 0.5f);

        //==== rotacja wzgledem x.left
        //transform.Rotate(Vector3.left);

        //==== obrot ciągły o 30st na sekunde, po 12 sekundach rotacja zrobi pełne koło
        //transform.RotateAround(new Vector3(-2, 0, 0), Vector3.back, 30 * Time.deltaTime);     

        //==== podąża za targetem, ustawia się do niego wg wskazanego kierunku
        //transform.LookAt(Target, Vector3.left);                                               

        //==== ustawia rotację transforma względem targetu
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Target.rotation, 30 * Time.deltaTime);

        //==== fraction calculations
        _timeFraction += (Time.deltaTime / _timeDuration);
    }
}

