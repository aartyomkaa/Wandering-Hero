using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _move;

    public void StartMove(Queue<Road> roads)
    {
        if (_move != null)
        {
            StopCoroutine(_move);
        }

        _move = StartCoroutine(Move(roads));
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
    }

    private IEnumerator Move(Queue<Road> roads)
    {
        while (roads.Count > 0)
        {
            Road road = roads.Dequeue();

            if (road != null)
            {
                Vector3 nextPosition = new Vector3(road.transform.position.x, 1, road.transform.position.z);

                while (transform.position != nextPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);

                    yield return Time.deltaTime;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<InterestTile>(out InterestTile tile))
        {

        }
    }
}
