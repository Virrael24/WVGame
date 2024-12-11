using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public List<Image> HPImages;
    public Image HPImagePrefab;
    public int MaxHP;
    public int CurrentHP;
    public Sprite FullHP;
    public Sprite EmptyHP;
    
    void Start()
    {
        for (int i = 0; i < MaxHP; i++)
        {
            Image image = Instantiate(HPImagePrefab);
            HPImages.Add(image);
            image.transform.parent = transform;
            image.sprite = FullHP;
        }
        CurrentHP = MaxHP;
    }

    public void ChangeHp(int hp)
    {
        if (hp > 0 && CurrentHP < MaxHP)
        {
            CurrentHP += hp;
            if(CurrentHP > MaxHP)
                CurrentHP = MaxHP;
            for (int i = 0; i < CurrentHP ; i++) 
            { 
                HPImages[i].sprite = FullHP;
            }
        }
        else if(CurrentHP > 0 && hp < 0) 
        {
            CurrentHP += hp;
            if(CurrentHP < 0) 
            {
                CurrentHP = 0; 
            }
            for (int i = MaxHP; i > 0; i--)
            {
                HPImages[i-1].sprite = EmptyHP;
            }
            for (int i = 0; i < CurrentHP; i++)
            {
                HPImages[i].sprite = FullHP;
            }
        }

        if(CurrentHP <= 0)
        {

        }
    }
}
