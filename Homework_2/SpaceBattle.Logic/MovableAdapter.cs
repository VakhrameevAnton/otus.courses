using System;
using SpaceBattle.Logic.Interfaces;

namespace SpaceBattle.Logic
{
    public class MovableAdapter : IMovable
    {
        public IUObject O;
        public MovableAdapter(IUObject o)
        {
            O = o;
        }
        
        public MovableAdapter()
        {
        }
        
        public Vector GetPosition()
        {
            return (Vector)O.GetProperty("Position");
        }

        public void SetPosition(Vector newV)
        {
            O.SetProperty("Position", newV);
        }

        public Vector GetVelocity()
        {
            int d = (int)O.GetProperty("Direction");
            int n = (int)O.GetProperty("DirectionsNumber");
            int v = (int)O.GetProperty("Velocity");

            return new Vector(v * Math.Cos((double)d / 360 * n), v * Math.Sin((double)d / 360 * n));
        }
    }
}