using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public Camera cam;

	Vector3 mousePosition;
	
	// Update is called once per frame
	void Update () {

		// Pega posição do mouse na tela e converte na posição do espaço do jogo.
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		// Calcula vetor que descreve a direção que sai do firePoint para o mouse (Valei-me Geometria Analítica!!).
		Vector2 aimDir = mousePosition - firePoint.position;

		// Usa arco-tangente pra calcular o angulo descrito pelo vetor direção, para girar o firePoint.
		float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg; // Sim, é (y, x) sabe Deus pq !?

		// Atualiza rotação de firePoint
		firePoint.transform.eulerAngles = new Vector3(
			firePoint.transform.eulerAngles.x,
			firePoint.transform.eulerAngles.y,
			angle
		);

		// Atira!
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
