using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using static Assets.Scripts.Types;

namespace Assets.Scripts.Units
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField]
        public Status status = Status.Chill;
        public bool IsWalking = false;

        [SerializeField]
        private AttackType attackType = AttackType.Distant;

        protected NavMeshAgent Agent;
        public float Damage = 10f;

        [SerializeField]
        public float ShootDelay = 0.2f;

        [SerializeField]
        public float AttackRadius;

        public Team Team;
        public float ShootTime;
        protected Animator Anime;
        protected AudioSource _audio;

        public virtual void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Team = GetComponent<DamagedObject.DamagedObject>().team;
            Anime = GetComponent<Animator>();
            _audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            ShootTime -= Time.deltaTime;

            switch (status)
            {
                case Status.Selected:
                    break;
                case Status.Fighting:
                    UpdateFighting();
                    break;
                case Status.Working:
                    UpdateWorking();
                    break;
                case Status.Chill:
                    break;
                case Status.Guarding:
                    Guard();
                    break;
                default:
                    break;
            }

            if (Vector3.Distance(Agent.destination, transform.position) < 40)
                IsWalking = false;

            if (IsWalking)
                Anime.SetBool("Chill", false);
            else
                Anime.SetBool("Chill", true);
        }


        public virtual void UpdateFighting()
        {
            var target = Resources.AllObjects.Where(x => x != null)
                                            .Where(x => (int)x.team == ((int)Team + 1) % 2)
                                            .Distinct()
                                            .ToList();

            FindAim(target);
        }
        public virtual void UpdateWorking()
        {
            var target = Resources.AllObjects.Where(x => x != null)
                                            .Where(o => o.team == Team.Wood);

            FindAim(target);
        }

        public virtual void AttackNotFriends()
        {
            var target = Resources.AllObjects.Where(x => x != null)
                                            .Where(o => o.team != Team.Friend);
            FindAim(target, false);
        }

        private void FindAim(IEnumerable<DamagedObject.DamagedObject> target, bool goToAim = true)
        {
            var minDist = float.MaxValue;
            DamagedObject.DamagedObject minObj = default;

            if (attackType == AttackType.Near)
            {
                if (ShootTime < 0)
                {
                    foreach (var obj in target)
                    {
                        //RaycastHit hitInfo;
                        //Physics.Raycast(transform.position, obj.transform.position, out hitInfo, 100000);
                        var distance = Vector3.Distance(transform.position, obj.transform.position);
                        //Debug.Log(distance);
                        Hit(obj, distance);
                        if (distance < minDist)
                        {
                            minDist = distance;
                            minObj = obj;
                        }
                    }
                    ShootTime = ShootDelay;
                }
            }
            else if (attackType == AttackType.Distant)
            {
                foreach (var obj in target)
                {
                    //RaycastHit hitInfo;
                    //Physics.Raycast(transform.position, obj.transform.position, out hitInfo, 100000);
                    var distance = Vector3.Distance(transform.position, obj.transform.position);
                    //Debug.Log(distance);
                    if (distance < minDist)
                    {
                        minDist = distance;
                        minObj = obj;
                    }
                }
                Hit(minObj, minDist);
            }

            if (goToAim && minObj != default && minDist > AttackRadius)
            {
                if (Vector3.Distance(Agent.destination, minObj.gameObject.transform.position) > 40)
                    Agent.ResetPath();

                //Debug.Log(minObj.gameObject.transform.position);
                Agent.SetDestination(minObj.gameObject.transform.position);
                GetComponent<Unit>().IsWalking = true;
            }
        }

        //public virtual void UpdateFighting()
        //{
        //    var toBit = Resources.AllObjects.Where(x => x != null)
        //                        .Where(x => (int)x.team == ((int)Team + 1) % 2);

        //    var minDist = float.MaxValue;
        //    DamagedObject.DamagedObject minObj = default;

        //    foreach (var obj in toBit)
        //    {
        //        if (obj != null)
        //        {
        //            var distance = Vector3.Distance(transform.position, obj.transform.position);

        //            if (distance < minDist)
        //            {
        //                minDist = distance;
        //                minObj = obj;
        //            }
        //        }
        //    }

        //    if (minObj != default && minDist > AttackRadius)
        //    {
        //        //agent.ResetPath();
        //        Agent.SetDestination(minObj.gameObject.transform.position);
        //    }

        //    if (minDist <= AttackRadius)
        //    {
        //        //Debug.Log($"союзник хочет ударить на {minObj.name}");
        //        DistHit(minObj);
        //    }
        //}

        //public virtual void UpdateWorking()
        //{
        //    var woods = Resources.AllObjects.Where(x => x != null)
        //                                    .Where(o => o.team == Team.Wood);

        //    var minDist = float.MaxValue;
        //    DamagedObject.DamagedObject minObj = default;

        //    foreach (var obj in woods)
        //    {
        //        var distance = Vector3.Distance(transform.position, obj.transform.position);

        //        if (distance < minDist)
        //        {
        //            minDist = distance;
        //            minObj = obj;
        //        }
        //    }

        //    if (minObj != default && minDist > AttackRadius)
        //    {
        //        //agent.ResetPath();
        //        Agent.SetDestination(minObj.gameObject.transform.position);
        //    }

        //    if (minDist <= AttackRadius)
        //    {
        //        //Debug.Log($"союзник хочет ударить на {minObj.name}");
        //        DistHit(minObj);
        //    }
        //}
        
        //public virtual void DistHit(DamagedObject.DamagedObject gameObject)
        //{
        //    //var gameObjects = FindObjectsOfType<DamagedObject>();
        //    //RaycastHit hit;
        //    transform.LookAt(gameObject.transform.position);
        //    DoDamage(gameObject);
        //    //Debug.Log($"союзник нападает на {gameObject.name}");
        //    //if (Physics.Raycast(transform.position, gameObject.transform.position, out hit, 100000))
        //    //{
        //    //    //transform.LookAt(hit.point);
        //    //    var dist = Vector3.Distance(hit.collider.transform.position, hit.point);

        //    //    if (dist < _attackRadius)
        //    //    {
        //    //        Debug.Log($"союзник нападает на {hit.collider.gameObject.name}");
        //    //        DoDamage(hit.collider.gameObject.GetComponent<DamagedObject>());
        //    //    }
        //    //}
        //}

        public virtual void DoDamage(DamagedObject.DamagedObject e)
        {
            if (ShootTime < 0)
            {
                ShootTime = ShootDelay;
                //Anime.SetTrigger("Attack");
                if (e != null)
                    e.ApplyDamage(Damage);
                else
                    Debug.Log("Ego bit nizya!");
            }
            //Anime.ResetTrigger("Attack");
        }

        public virtual void Guard()
        {
            if (Random.value > 0.5)
            {
                float x = 0;
                float z = 0;

                if (Random.value > 0.5)
                {
                    x = Random.Range(-10, 0);
                    z = Random.Range(-10, 0);
                }
                else
                {
                    x = Random.Range(0, 10);
                    z = Random.Range(0, 10);
                }

                //var position = transform.position + new Vector3(x, 0, z);

                //transform.Translate(position);
            }
        }


        private void Hit(DamagedObject.DamagedObject obj, float distance)
        {
            if (distance <= AttackRadius)
            {
                transform.LookAt(obj.transform.position);
                if (attackType == AttackType.Near)
                {
                    Anime.SetTrigger("Attack");

                    obj.ApplyDamage(Damage);

                    if (_audio != null)
                        _audio.Play();

                    Anime.ResetTrigger("Attack");
                }
                else if (attackType == AttackType.Distant)
                {
                    if (ShootTime < 0)
                    {
                        Anime.SetTrigger("Attack");

                        obj.ApplyDamage(Damage);
                        if(_audio != null)
                            _audio.Play();
                        ShootTime = ShootDelay;

                        Anime.ResetTrigger("Attack");
                    }
                    //Debug.Log($"союзник хочет ударить на {minObj.name}");
                }
            }
        }

    }
}
