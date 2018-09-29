using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessWorkflowHost
{
    public class StatusTrackingParticipant: TrackingParticipant
    {
        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            ActivityStateRecord asr = record as ActivityStateRecord;

            if (asr != null)
            {
                if (asr.State == ActivityStates.Executing &&
                    asr.Activity.TypeName == "System.Activities.Statements.WriteLine")
                {
                    // Append the WriteLine output to the tracking  
                    // file for this instance  
                    using (StreamWriter writer = File.AppendText(record.InstanceId.ToString()))
                    {
                        writer.WriteLine(asr.Arguments["Text"]);
                        writer.Close();
                    }
                }
            }
        }
    }
}
