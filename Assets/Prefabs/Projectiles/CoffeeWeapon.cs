using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWeapon : MonoBehaviour {

	public CharacterController2D controller;
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Camera cam;

	Vector3 mousePosition;
	
	// Update is called once per frame
	void Update () {

		// Atira!
		if (Input.GetButtonDown("Fire1"))
		{
			if (mousePosition.x < firePoint.position.x && controller.m_FacingRight)
			{
				controller.Flip();
			}
			else if (firePoint.position.x < mousePosition.x && !controller.m_FacingRight) {
				controller.Flip();
			}

			// Pega posição do mouse na tela e converte na posição do espaço do jogo.
			mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

			// Calcula vetor que descreve a direção que sai do firePoint para o mouse (Valei-me Geometria Analítica!!).
			Vector2 aimDir = mousePosition - firePoint.position;

			// Inverte x se estiver olhando para esquerda, exceto que o nome da variável está invertido no script.
			// Semanticamente falando deveria ser !controller.m_FacingLeft mas foda-se...
			if (!controller.m_FacingRight)
			{
				aimDir.x = aimDir.x * -1;
			}

			// Usa arco-tangente pra calcular o angulo descrito pelo vetor direção, para girar o firePoint.
			float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg; // Sim, é (y, x) sabe Deus pq !?

			// Atualiza rotação de firePoint
			firePoint.transform.eulerAngles = new Vector3(
				firePoint.transform.eulerAngles.x,
				firePoint.transform.eulerAngles.y,
				angle
			);

			Shoot();
		}
	}

	void Shoot ()
	{
		firePoint.GetComponent<AudioSource>().Play();
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
