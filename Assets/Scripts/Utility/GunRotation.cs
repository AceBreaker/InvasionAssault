using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;
using System;

public class GunRotation : MonoBehaviour
{

    public int rotationOffset;
    private PlatformerCharacter2D player;

    void Awake()
    {
        player = GetComponentInParent<PlatformerCharacter2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize(); //normalizing the vector. Meaning that all the sum of the vectotr will be equal to 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //find the angle in degrees
        int facingMultiplier = FacingMultiplier();
        rotationOffset = 180 * Convert.ToInt32(!player.FacingRight);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotZ + rotationOffset * facingMultiplier);
    }

    private int FacingMultiplier()
    {
        return -1 + Convert.ToInt32(player.FacingRight) * 2;
    }
}