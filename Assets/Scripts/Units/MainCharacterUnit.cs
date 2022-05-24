using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static Assets.Scripts.Types;

namespace Assets.Scripts.Units
{
    internal class MainCharacterUnit : Unit
    {
        //[SerializeField]
        //private AttackType attackType;
        //public LayerMask whatCanBeClickedOn;

        //private AudioSource _audio;

        //public override void Start()
        //{
        //    _audio = GetComponent<AudioSource>();
        //    Agent = GetComponent<NavMeshAgent>();
        //    Team = GetComponent<DamagedObject.DamagedObject>().team;
        //    Anime = GetComponent<Animator>();
        //}

        //public override void Update()
        //{
        //    ShootTime -= Time.deltaTime;

        //    //if (Input.GetMouseButtonDown(1))
        //    //{
        //    //    var toBit = Resources.AllObjects.Where(x => x != null)
        //    //                    .Where(x => x.team != Team)
        //    //                    .Select(x => x.GetComponent<NavMeshAgent>());

        //    //    status = Status.Chill;

        //    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    //    RaycastHit hitInfo;
        //    //    if (Physics.Raycast(ray, out hitInfo, 10000, whatCanBeClickedOn))
        //    //    {
        //    //        foreach (var agent in toBit)
        //    //        {
        //    //            agent.ResetPath();
        //    //            agent.SetDestination(hitInfo.point);
        //    //        }
        //    //    }

        //    //    HitAllInRadius();
        //    //}
        //    //Debug.Log(status);
        //    switch (status)
        //    {
        //        case Status.Selected:
        //            Anime.SetBool("Chill", false);
        //            break;
        //        case Status.Fighting:
        //            Anime.SetBool("Chill", false);
        //            UpdateFighting();
        //            break;
        //        case Status.Working:
        //            Anime.SetBool("Chill", false);
        //            UpdateWorking();
        //            break;
        //        case Status.Chill:
        //            //Anime.SetBool("Chill", true);
        //            break;
        //        case Status.Guarding:
        //            Anime.SetBool("Chill", false);
        //            Guard();
        //            break;
        //        default:
        //            break;
        //    }

        //    if (Vector3.Distance(Agent.destination, transform.position) < 40)
        //        Anime.SetBool("Chill", true);
        //}



        //public override void UpdateFighting()
        //{
        //    var toBit = Resources.AllObjects.Where(x => x != null)
        //                                    .Where(x => (int)x.team == ((int)Team + 1) % 2)
        //                                    .Distinct()
        //                                    .ToList();

        //    FindAim(toBit);
        //}
        //public override void UpdateWorking()
        //{
        //    var woods = Resources.AllObjects.Where(x => x != null)
        //                                    .Where(o => o.team == Team.Wood);

        //    FindAim(woods);
        //}

        //private void FindAim(IEnumerable<DamagedObject.DamagedObject> target)
        //{
        //    var minDist = float.MaxValue;
        //    DamagedObject.DamagedObject minObj = default;

        //    if (attackType == AttackType.Near)
        //    {
        //        if (ShootTime < 0)
        //        {
        //            foreach (var obj in target)
        //            {
        //                //RaycastHit hitInfo;
        //                //Physics.Raycast(transform.position, obj.transform.position, out hitInfo, 100000);
        //                var distance = Vector3.Distance(transform.position, obj.transform.position);
        //                //Debug.Log(distance);
        //                Hit(obj, distance);
        //                if (distance < minDist)
        //                {
        //                    minDist = distance;
        //                    minObj = obj;
        //                }
        //            }
        //            ShootTime = ShootDelay;
        //        }
        //    }
        //    else if (attackType == AttackType.Distant)
        //    {
        //        foreach (var obj in target)
        //        {
        //            //RaycastHit hitInfo;
        //            //Physics.Raycast(transform.position, obj.transform.position, out hitInfo, 100000);
        //            var distance = Vector3.Distance(transform.position, obj.transform.position);
        //            //Debug.Log(distance);
        //            if (distance < minDist)
        //            {
        //                minDist = distance;
        //                minObj = obj;
        //            }
        //        }
        //        Hit(minObj, minDist);
        //    }

        //    if (minObj != default && minDist > AttackRadius)
        //    {
        //        if (Vector3.Distance(Agent.destination, minObj.gameObject.transform.position) > 40)
        //            Agent.ResetPath();
        //        Debug.Log(minObj.gameObject.transform.position);
        //        Agent.SetDestination(minObj.gameObject.transform.position);
        //    }
        //}

        //private void Hit(DamagedObject.DamagedObject obj, float distance)
        //{
        //    if (distance <= AttackRadius)
        //    {
        //        transform.LookAt(obj.transform.position);
        //        if (attackType == AttackType.Near)
        //        {
        //            Anime.SetTrigger("Attack");

        //            obj.ApplyDamage(Damage);
        //            _audio.Play();

        //            Anime.ResetTrigger("Attack");
        //        }
        //        else if (attackType == AttackType.Distant)
        //        {
        //            if (ShootTime < 0)
        //            {
        //                Anime.SetTrigger("Attack");

        //                obj.ApplyDamage(Damage);
        //                _audio.Play();
        //                ShootTime = ShootDelay;

        //                Anime.ResetTrigger("Attack");
        //            }
        //            //Debug.Log($"союзник хочет ударить на {minObj.name}");
        //        }
        //    }
        //}
    }
}

public enum AttackType
{
    Near,
    Distant
}