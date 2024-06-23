using System;

namespace Client.Scripts.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel; //just an example for this placeholder. en efficient way to save some Unity types data

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel, new Vector3Data(0,0,0));
        }
    }
}