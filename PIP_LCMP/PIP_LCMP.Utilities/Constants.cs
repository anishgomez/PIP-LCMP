using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIP_LCMP.Utilities
{
    public static class Constants
    {
        public const string JWTTokenIssuer = "PartnersInPerfomance";
        public const string JWTTokenSecurityKey = "JWTTokenKey";
        public const string UnauthorizedMessage = "You are not authorized to access this page";
        public const int TokenExpiry = 240;
        public const string InvalidLogin = "Username/Password doesnot match";
        public const string NoFleets = "No fleets found";
        public const string NoFleetModels = "No fleet models found";
        public const string NoEquipments = "No equipments found";
    }
}
