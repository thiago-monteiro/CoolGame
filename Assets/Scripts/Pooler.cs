using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler self;
    public GearBot GearBotPrefab;
    public Bullet BulletPrefab;
    private List<GearBot> bots;
    private List<Bullet> bullets;
    public int botAmount = 5;
    public int bulletAmount = 5;

    void Awake(){
        self = this;
        bots = new List<GearBot>(botAmount);
        for (int i = 0; i < botAmount; i++){
            GearBot gb = Instantiate(GearBotPrefab);
            gb.transform.SetParent(transform);
            gb.gameObject.SetActive(false);
            bots.Add(gb);
        }
        bullets = new List<Bullet>(bulletAmount);
        for (int i = 0; i < bulletAmount; i++){
            Bullet bullet = Instantiate(BulletPrefab);
            bullet.transform.SetParent(transform);
            bullet.gameObject.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public GearBot GetGearBot(){
        foreach(GearBot bot in bots){
            if (!bot.gameObject.activeInHierarchy){
                bot.gameObject.SetActive(true);
                return bot;
            }
        }
        GearBot prefabInstance = Instantiate(GearBotPrefab);
        prefabInstance.transform.SetParent(transform);
        bots.Add(prefabInstance);
        return prefabInstance;
    }
    public Bullet GetBullet(){
        foreach(Bullet bullet in bullets){
            if (!bullet.gameObject.activeInHierarchy){
                 bullet.gameObject.SetActive(true);
                return bullet;
            }
        }
        Bullet prefabInstance = Instantiate(BulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);
        return prefabInstance;
    }
}
