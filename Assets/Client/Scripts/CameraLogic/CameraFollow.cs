using UnityEngine;

namespace Client.Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] 
        private float rotationAngleX = 55f;
        [SerializeField]
        private float distance = 25f;
        [SerializeField]
        private float offsetY = .5f;
        
        [SerializeField] 
        private Transform following;

        private void LateUpdate()
        {
            if (following == null) 
                return;

            Quaternion rotation = Quaternion.Euler(rotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject following) => this.following = following.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = following.position;
            followingPosition.y += offsetY;
            
            return followingPosition;
        }
    }
}