using Assets.Scripts.Units;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.UI
{
    public class GameInterfaceButton : MonoBehaviour
    {
        public GameObject controllElements;
        public GameObject shop;
        public LayerMask whatCanBeClickedOn;

        void Update()
        {
            Debug.Log(shop.transform.position);
            if (Resources.SelectedUnits.Count > 0 &&
                !(controllElements.transform.position.x <= Input.mousePosition.x &&
                controllElements.transform.position.y >= Input.mousePosition.y)&&
                !(shop.transform.position.x <= Input.mousePosition.x &&
                shop.transform.position.y >= Input.mousePosition.y && shop.active))
            {
                if (Input.GetMouseButtonDown(0))
                {

                    var units = Resources.SelectedUnits.Where(x => x != null)
                                                .Select(obj => obj.GetComponent<NavMeshAgent>());

                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    RaycastHit hitInfo;
                    if (Physics.Raycast(ray, out hitInfo, 10000))
                    {
                        foreach (var agent in units)
                        {
                            agent.ResetPath();
                            agent.SetDestination(hitInfo.point);
                            var unit = agent.GetComponent<Unit>();
                            unit.IsWalking = true;
                            unit.status = Types.Status.Chill;
                        }
                    }
                }

                if (Input.GetMouseButtonDown(1))
                {
                    var units = Resources.SelectedUnits.Where(x => x != null)
                                                .Select(obj => obj.GetComponent<Unit>());
                    foreach (var unit in units)
                    {
                        unit.AttackNotFriends();
                    }
                    //var toBit = Resources.AllObjects.Where(x => x != null)
                    //                .Where(x => x.team != Types.Team.Friend)
                    //                .Select(x => x.GetComponent<NavMeshAgent>());

                        //status = Status.Chill;

                        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                        //RaycastHit hitInfo;
                        //if (Physics.Raycast(ray, out hitInfo, 10000))
                        //{
                        //    foreach (var agent in toBit)
                        //    {
                        //        agent.ResetPath();
                        //        agent.SetDestination(hitInfo.point);
                        //    }
                        //}

                    //HitAllInRadius();
                }
            }
        }

        public void Attack()
        {
            var friendlyUnits = Resources.SelectedUnits.Where(x => x != null)
                                                .Select(obj => (Unit)obj.GetComponent<FriendlyUnit>());
            var mainHero = Resources.SelectedUnits.Where(x => x != null)
                                                .Select(obj => (Unit)obj.GetComponent<MainCharacterUnit>());

            foreach (var unit in friendlyUnits.Union(mainHero))
            {
                if (unit != null)
                {
                    var nma = unit.GetComponent<NavMeshAgent>();
                    if (nma != null)
                        nma.ResetPath();
                    unit.status = Types.Status.Fighting;
                }
            }
        }

        public void Stay()
        {
            var friendlyUnits = Resources.SelectedUnits.Where(x => x != null)
                                                 .Select(obj => (Unit)obj.GetComponent<FriendlyUnit>());
            var mainHero = Resources.SelectedUnits.Where(x => x != null)
                                             .Select(obj => (Unit)obj.GetComponent<MainCharacterUnit>());

            foreach (var a in friendlyUnits.Union(mainHero))
            {
                if (a != null)
                {
                    var nma = a.GetComponent<NavMeshAgent>();
                    if (nma != null)
                        nma.ResetPath();
                    a.status = Types.Status.Chill;
                }
            }
        }

        public void Work()
        {
            var friendlyUnits = Resources.SelectedUnits.Where(x => x != null)
                                                 .Select(obj => (Unit)obj.GetComponent<FriendlyUnit>());
            var mainHero = Resources.SelectedUnits.Where(x => x != null)
                                             .Select(obj => (Unit)obj.GetComponent<MainCharacterUnit>());

            foreach (var a in friendlyUnits.Union(mainHero))
            {
                if (a != null)
                {
                    var nma = a.GetComponent<NavMeshAgent>();
                    if (nma.pathEndPosition != null)
                        nma.ResetPath();
                    
                    a.status = Types.Status.Working;
                }
            }
        }
    }
}
