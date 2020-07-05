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

        private double _centerPosX;
        private double _centerPosY;

        private double _vel;
        private double _velX;
        private double _velY;

        //TODO Delete this attribute afte Route class is created
        private List<Station> _route = new List<Station>();

        private Station _origin;
        private Station _destination;

        #endregion

        #region Public properties

        public double CenterPosX
        {
            get { return _centerPosX; }
            set
            {
                _centerPosX = value;
                PosX = CenterPosX - Width / 2;
                OnPropertyChanged(nameof(CenterPosX));
            }
        }

        public double CenterPosY
        {
            get { return _centerPosY; }
            set
            {
                _centerPosY = value;
                PosY = CenterPosY - Height / 2;
                OnPropertyChanged(nameof(CenterPosY));
            }
        }

        public double Vel
        {
            get { return _vel; }
            set
            {
                _vel = value;
                OnPropertyChanged(nameof(Vel));
            }
        }

        public double VelX
        {
            get { return _velX; }
            set
            {
                _velX = value;
                OnPropertyChanged(nameof(VelX));
            }
        }

        public double VelY
        {
            get { return _velY; }
            set
            {
                _velY = value;
                OnPropertyChanged(nameof(VelY));
            }
        }


        public List<Station> Route
        {
            get { return _route; }
            set
            {
                _route = value;
                OnPropertyChanged(nameof(Route));
            }
        }

        public Station Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                OnPropertyChanged(nameof(Origin));
            }
        }

        public Station Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        #endregion

        #region Constructor

        public Transport(int id, string name, int level, double posX, double posY, double width, double height,
            double vel)
            : base(id, name, level, posX, posY, width, height)
        {
            // PosX & PosY by CenterPosX & CenterPosY


            CenterPosX = posX;
            CenterPosY = posY;

            Vel = vel;
        }

        #endregion

        internal void UpdateTransport(TimeSpan worldElapsedTime)
        {
            CenterPosX += VelX * worldElapsedTime.TotalSeconds / 3600;
            CenterPosY += VelY * worldElapsedTime.TotalSeconds / 3600;

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
            if (Math.Abs(CenterPosX - Destination.CenterPosX) < 2
                && Math.Abs(CenterPosY - Destination.CenterPosY) < 2)
            {
                CenterPosX = Destination.CenterPosX;
                CenterPosY = Destination.CenterPosY;
                return true;
            }

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
                Route.Reverse();
                return Route.ElementAt(1);
            }
        }
    }
}
