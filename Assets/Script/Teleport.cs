	
using UnityEngine;

using System.Collections;



public class Teleport : MonoBehaviour
{
	public bool spiderMman;
	private RaycastHit lastRaycastHit;

	public GameObject teleportMarker;

	public AudioClip audioClip;

	public float range = 1000;

	[Range(1f,100f)]
	public float spedMove = 50f;



	void Start () {

		teleportMarker.gameObject.SetActive (false);
		if (!spiderMman) {
			Physics.gravity = Vector3.up * -10f;
		}
	}

	void LateUpdate()

	{

		//Confirmamos teleportación
		if (Input.GetButtonUp("Fire2")){
			if (GetLookedAtObject () != null)
				StartCoroutine (TeleportToLookAt ());
			teleportMarker.SetActive (false);
		}

		if (Input.GetButtonDown("Fire2")) {
			teleportMarker.SetActive (true);
		}

		//Mientras elegimos donde mostramos el sistema de partículas
		if (Input.GetButton("Fire2")) {
			GameObject currentTarget = GetLookedAtObject ();
			if (currentTarget != null && currentTarget.tag == "Suelo")
				teleportMarker.transform.position = lastRaycastHit.point + Vector3.up*0.01f;
		}

	}



	private GameObject GetLookedAtObject()

	{

		Vector3 origin = Camera.main.transform.position;

		Vector3 direction = Camera.main.transform.forward;

		if (Physics.Raycast(origin, direction, out lastRaycastHit, range) && (lastRaycastHit.normal.normalized.Equals(Vector3.up)|| spiderMman)) //Si es tipo suelo el objeto

		{

			return lastRaycastHit.collider.gameObject;

		}

		else

		{

			return null;

		}

	}



	private IEnumerator TeleportToLookAt()

	{

		Vector3 destinationPoint = lastRaycastHit.point + lastRaycastHit.normal * 1.5f;

		if (audioClip != null)
			AudioSource.PlayClipAtPoint(audioClip, transform.position);

		//Nos movemos hacia el destino
		while (Vector3.Distance (transform.position, destinationPoint) > 0.3f) {
			transform.position = Vector3.MoveTowards (transform.position, destinationPoint, spedMove * Time.deltaTime);
			//Esperamos un prame antes del siguiente movimiento
			yield return null;
		}

		yield return null;


	}




}
