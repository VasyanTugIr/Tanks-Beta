using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulFuelTank : ModulBase
{
    private List<ModulBase> _damagedModules;
    [SerializeField] private GameObject _fire;

    private bool _isBurn;
    private void Start()
    {
        _damagedModules = new List<ModulBase>();

    }

    public override void modulDamaged()
    {
        base.modulDamaged();
        BurnWithChance(100);
    }

    public override void modulDestroyed()
    {
        base.modulDestroyed();
        BurnWithChance(20);
    }


    private void BurnWithChance(int chance)
    {
        var isBurn = Random.Range(0, 100) <= chance;

        if (isBurn)
        {
            _fire.SetActive(true);
            print("Start burning");
            _isBurn = true;
            StartCoroutine(BurnDamage());
            
        }
    }

    private IEnumerator BurnDamage()
    {
        while (_isBurn)
        {
            foreach(ModulBase modul in _damagedModules)
            {
                modul.GetDamage(3);
                print("burning");
                
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var isModul = other.gameObject.GetComponent<ModulBase>();

        if (isModul != null)
        {
            if (!_damagedModules.Contains(isModul))
            {
                _damagedModules.Add(isModul);
            }
           
        }

        
    }
}
