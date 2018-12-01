using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Transport : BaseCsGameEntity
    {
        #region Private attributes

        private double _Vel;
        private double _VelX;
        private double _VelY;

        private List<Station> _Route = new List<Station>();
        private Station _Origin;
        private Station _Destination;

        #endregion

        #region Public properties

        public double Vel
        {
            get { return _Vel; }
            set
            {
                _Vel = value;
                OnPropertyChanged(nameof(Vel));
            }
        }

        public double VelX
        {
            get { return _VelX; }
            set
            {
                _VelX = value;
                OnPropertyChanged(nameof(VelX));
            }
        }

        public double VelY
        {
            get { return _VelY; }
            set
            {
                _VelY = value;
                OnPropertyChanged(nameof(VelY));
            }
        }


        public List<Station> Route
        {
            get { return _Route; }
            set
            {
                _Route = value;
                OnPropertyChanged(nameof(Route));
            }
        }

        public Station Origin
        {
            get { return _Origin; }
            set
            {
                _Origin = value;
                OnPropertyChanged(nameof(Origin));
            }
        }

        public Station Destination
        {
            get { return _Destination; }
            set
            {
                _Destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        #endregion

        #region Constructor

        public Transport(int id, string name, int level, double posX, double posY, double width, double height,
            double vel)
            : base(id, name, level, posX, posY, width, height)
        {
            Vel = vel;
        }

        #endregion

        internal void UpdateTransport(TimeSpan worldElapsedTime)
        {
            PosX += VelX * worldElapsedTime.TotalSeconds / 3600;
            PosY += VelY * worldElapsedTime.TotalSeconds / 3600;

            if (IsArrived())
            {
                Origin = Destination;
                Destination = NextDestination();
                CalculateVels();
            }
        }

        internal void CalculateVels()
        {
            double distanceFromOriginToDestination = Math.Sqrt(
                Math.Pow(Destination.CenterPosX - Origin.CenterPosX, 2)
                + Math.Pow(Destination.CenterPosY - Origin.CenterPosY, 2));

            VelX = Vel * (Destination.CenterPosX - Origin.CenterPosX) / distanceFromOriginToDestination;
            VelY = Vel * (Destination.CenterPosY - Origin.CenterPosY) / distanceFromOriginToDestination;
        }

        internal bool IsArrived()
        {
            if (Math.Abs(PosX - Destination.CenterPosX) < 2
                && Math.Abs(PosY - Destination.CenterPosY) < 2)
                return true;

            return false;
        }

        internal Station NextDestination()
        {
            int nextStationIndex = Route.IndexOf(Destination);

            if (nextStationIndex + 1 < Route.Count)
            {
                return Route.ElementAt(nextStationIndex + 1);
            }
            else
            {
                return Route.ElementAt(0);
            }
        }

    }
}
