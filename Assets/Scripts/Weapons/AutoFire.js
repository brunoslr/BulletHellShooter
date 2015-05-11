#pragma strict

@script RequireComponent (PerFrameRaycast)

var bulletPrefab : GameObject;
var flamePrefab : GameObject;
var bulletSpawnPoint : Transform;
var flameSpawnPoint : Transform;
var frequency : float = 10;
var coneAngle : float = 1.5;
var firing : boolean = false;
var damagePerSecond : float = 20.0;
var forcePerSecond : float = 20.0;
var hitSoundVolume : float = 0.5;
var distance : float = 0.0;
public var bulletRange : float = 20.0;
var muzzleFlashFront : GameObject;

private var lastFireTime : float = -1;
private var raycast : PerFrameRaycast;

public var clicked = false;

private var commonGameObject : GameObject;

function Start()
{
        
    commonGameObject = GameObject.Find("gameData");
	ChangeSpeed();
}

function Awake () {
	muzzleFlashFront.SetActive (false);

	raycast = GetComponent.<PerFrameRaycast> ();
	if (bulletSpawnPoint == null)
		bulletSpawnPoint = transform;
		

}

function fireBullet()
{
	muzzleFlashFront.SetActive (true);

	if (audio)
		audio.Play ();
		
	if (Time.time > lastFireTime + 1 / frequency) {
			// Spawn visual bullet
			
			var coneRandomRotation = Quaternion.Euler (Random.Range (-coneAngle, coneAngle), Random.Range (-coneAngle, coneAngle), 0);
			var go : GameObject = Spawner.Spawn (bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation * coneRandomRotation) as GameObject;
			var bullet : SimpleBullet = go.GetComponent.<SimpleBullet> ();

			lastFireTime = Time.time;

			// Find the object hit by the raycast
			var hitInfo : RaycastHit = raycast.GetHitInfo ();
			
			distance = Vector3.Distance(hitInfo.transform.position,this.transform.position);
			//Debug.Log(distance);
			
			if (hitInfo.transform && distance < bulletRange) {
				// Get the health component of the target if any
				var targetHealth : Health = hitInfo.transform.GetComponent.<Health> ();
				if (targetHealth) {
					// Apply damage
					targetHealth.OnDamage (damagePerSecond / frequency, -bulletSpawnPoint.forward);
				}

				// Get the rigidbody if any
				if (hitInfo.rigidbody) {
					// Apply force to the target object at the position of the hit point
					var force : Vector3 = transform.forward * (forcePerSecond / frequency);
					hitInfo.rigidbody.AddForceAtPosition (force, hitInfo.point, ForceMode.Impulse);
				}

				// Ricochet sound
				var sound : AudioClip = MaterialImpactManager.GetBulletHitSound (hitInfo.collider.sharedMaterial);
				AudioSource.PlayClipAtPoint (sound, hitInfo.point, hitSoundVolume);

				bullet.dist = hitInfo.distance;
			}
		}
}

function Update () {

	if(Input.GetMouseButtonDown(0))
	{
		fireBullet();
	}
	//if(Input.GetMouseButtonUp(1))
	{
		muzzleFlashFront.SetActive (false);
		if (audio)
				audio.Stop ();
	}
	
	if (firing) {

		if (Time.time > lastFireTime + 1 / frequency) {
			// Spawn visual bullet
			var coneRandomRotation = Quaternion.Euler (Random.Range (-coneAngle, coneAngle), Random.Range (-coneAngle, coneAngle), 0);
			var go : GameObject = Spawner.Spawn (flamePrefab, flameSpawnPoint.position, flameSpawnPoint.rotation * coneRandomRotation) as GameObject;
			var bullet : SimpleBullet = go.GetComponent.<SimpleBullet> ();

			lastFireTime = Time.time;

			// Find the object hit by the raycast
			var hitInfo : RaycastHit = raycast.GetHitInfo ();
			
			distance = Vector3.Distance(hitInfo.transform.position,this.transform.position);
			//Debug.Log(distance);
			
			if (hitInfo.transform && distance < 5) {
				// Get the health component of the target if any
				var targetHealth : Health = hitInfo.transform.GetComponent.<Health> ();
				if (targetHealth) {
					// Apply damage
					targetHealth.OnDamage (damagePerSecond*2.5f / frequency, -flameSpawnPoint.forward);
				}

				// Get the rigidbody if any
				if (hitInfo.rigidbody) {
					// Apply force to the target object at the position of the hit point
					var force : Vector3 = transform.forward * (forcePerSecond / frequency);
					hitInfo.rigidbody.AddForceAtPosition (force, hitInfo.point, ForceMode.Impulse);
				}

				// Ricochet sound
				//var sound : AudioClip = MaterialImpactManager.GetBulletHitSound (hitInfo.collider.sharedMaterial);
				//AudioSource.PlayClipAtPoint (sound, hitInfo.point, hitSoundVolume);

				bullet.dist = hitInfo.distance;

				OnStopFire();
			}
			//else {
			//	bullet.dist = 1;
			//}
		}
	}
}


function OnStartFire () {
	if (Time.timeScale == 0)
		return;

	firing = true;

	//Debug.Log("firing");
	
	muzzleFlashFront.SetActive (true);

	//if (audio)
		//audio.Play ();
}

function OnStopFire () {
	firing = false;

	muzzleFlashFront.SetActive (false);

	//Debug.Log("Not firing");

	//if (audio)
		//audio.Stop ();
}

function ChangeSpeed()
{
    frequency = 0.0;
    frequency = commonGameObject.transform.localScale.z + 5.0;
    if(frequency <= 5)
        frequency = 5;

}
