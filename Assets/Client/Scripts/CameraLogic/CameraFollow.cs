using UnityEngine;

namespace Client.Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;
        
        [SerializeField] 
        private Transform following;

        private void LateUpdate()
        {
            if (following == null) 
                return;

            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);

            Vector3 position = rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject following) => this.following = following.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = following.position;
            followingPosition.y += OffsetY;
            
            return followingPosition;
        }
    }
}