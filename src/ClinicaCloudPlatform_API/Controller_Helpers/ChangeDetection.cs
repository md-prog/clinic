using System;

namespace ClinicaCloudPlatform.API.Controller_Helpers
{
    public static class ChangeDetection
    {
        public static object GetChangedValue(object Source, object Destination, ref bool alreadyChanged)
        {
            object retVal = Destination;
            alreadyChanged = alreadyChanged ? true : Object.Equals(Source, Destination);
            Destination = Source;
            return retVal;
        }
    }
}
