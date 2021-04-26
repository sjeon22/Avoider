using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<WaypointScript> Waypoints = new List<WaypointScript>();
    public float speed = 1.0f;
    public int destinationWaypoint = 1;
    public float chaseSpeed;
    public float chaseRange;
    public Transform player;
    public Transform respawnPoint;

    private Vector3 Destination;
    private bool Forwards = true;

    // Start is called before the first frame update
    void Start()
    {
        this.Destination = this.Waypoints[destinationWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo());
    }

    IEnumerator MoveTo()
    {
        while ((transform.position - this.Destination).sqrMagnitude > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                this.Destination, this.speed * Time.deltaTime);
            yield return null;
        }

        if ((transform.position - this.Destination).sqrMagnitude <= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (this.Waypoints[destinationWaypoint].IsEndPoint)
        {
            if (this.Forwards)
                this.Forwards = false;
            else
                this.Forwards = true;
        }

        if (this.Forwards) // index location
            ++destinationWaypoint; // form point 1 to 2
        else
            --destinationWaypoint; // from point 2 to 1

        this.Destination = this.Waypoints[destinationWaypoint].transform.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) <= chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
