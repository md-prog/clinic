using System;
using System.Linq;
using ClinicaCloudPlatform.Model.Models;

namespace ClinicaCloudPlatform.DAL.Data.Functions
{
    public class Sequencing
    {
        public static string GetFormattedSequence<T>(string Prefix, int MinLength,
            string Delimiter, bool IncludeDatePart, string DotNetDateFormat) 
            where T : _LimsBaseClass, ITypeSequenced
        {
            int sequence = GetTypeSequenceNext<T>();
            string datePart = IncludeDatePart ? DateTime.UtcNow.ToString(DotNetDateFormat) : String.Empty;
            string paddedSequence = sequence.ToString().PadLeft(MinLength);
            return String.Format("{0}{1}{2}{3}{4}", Prefix, datePart, Delimiter, paddedSequence);
        }

        public static int GetTypeSequenceNext<T>()
            where T :_LimsBaseClass, ITypeSequenced
        {
            //use a new context so the new sequence can be saved immediately
            using (var context = new ArsMachinaLIMSContext())
            {
                var set = context.Set<T>();
                int current = 0, next = 1;

                var currentRecord = set.OrderByDescending(t => t.CurrentTypeSequenceNumber).FirstOrDefault(); //.Max(t => ((ITypeSequenced)t).CurrentTypeSequenceNumber);
                if (currentRecord != null)
                {
                    current = currentRecord.CurrentTypeSequenceNumber;
                    next = current + 1;

                    //for now be optimistic about concurrency, but...
                    currentRecord.CurrentTypeSequenceNumber = next;
                    context.SaveChangesAsync();
                }

                return next;
            }
        }
    }
}
