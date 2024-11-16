using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float bounciness = 0.8f;  // Tingkat pantulan bola
    public float friction = 0f;      // Gesekan bola
    public float mass = 1f;          // Massa bola

    void Start()
    {
        // Tambahkan komponen Rigidbody jika belum ada
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Set up Rigidbody properties
        rb.mass = mass;  // Atur massa bola
        rb.drag = 0f;    // Tidak ada drag agar bola tidak berhenti tiba-tiba
        rb.angularDrag = 0.05f;  // Sedikit pengurangan untuk rotasi bola
        rb.useGravity = true;  // Bola terkena gravitasi
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;  // Mode deteksi benturan

        // Tambahkan SphereCollider jika belum ada
        SphereCollider collider = GetComponent<SphereCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
        }

        // Buat physics material untuk bola
        PhysicMaterial ballMaterial = new PhysicMaterial();
        ballMaterial.bounciness = bounciness;  // Atur pantulan
        ballMaterial.dynamicFriction = friction;  // Atur gesekan saat bergerak
        ballMaterial.staticFriction = friction;  // Atur gesekan saat diam
        ballMaterial.frictionCombine = PhysicMaterialCombine.Minimum;  // Gesekan minimal
        ballMaterial.bounceCombine = PhysicMaterialCombine.Maximum;  // Pantulan maksimal

        // Terapkan physics material ke collider bola
        collider.material = ballMaterial;
    }
}
