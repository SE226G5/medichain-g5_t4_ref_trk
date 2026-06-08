namespace ReferralPortal;

public class AccessDeniedException : Exception
{
    public AccessDeniedException(string message) : base(message)
    {
    }
}

public class SampleTracker
{
    public string TrackSample(
        int doctorId,
        int patientDoctorId,
        string sampleStatus,
        bool resultApproved,
        bool requestResult,
        bool secureChannel)
    {
        if (doctorId != patientDoctorId)
        {
            throw new AccessDeniedException("Access denied");
        }

        string result = "";

        if (requestResult)
        {
            if (sampleStatus == "READY")
            {
                if (resultApproved)
                {
                    if (secureChannel)
                    {
                        result = "Final Result Sent Securely";
                    }
                    else
                    {
                        result = "Secure Channel Required";
                    }
                }
                else
                {
                    result = "Result Not Approved Yet";
                }
            }
            else
            {
                result = "Result Not Ready";
            }
        }

        return result;
    }
        public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message) : base(message)
        {
        }
    }

    public class SampleTracker
    {
        private const string ResultReady = "READY";

        public string TrackSample(
            int doctorId,
            int patientDoctorId,
            string sampleStatus,
            bool resultApproved,
            bool requestResult,
            bool secureChannel)
        {
            ValidateAccess(doctorId, patientDoctorId);

            if (!requestResult)
                return string.Empty;

            if (!IsResultReady(sampleStatus))
                return "Result Not Ready";

            if (!resultApproved)
                return "Result Not Approved Yet";

            if (!secureChannel)
                return "Secure Channel Required";

            return "Final Result Sent Securely";
        }

        private void ValidateAccess(int doctorId, int patientDoctorId)
        {
            if (doctorId != patientDoctorId)
                throw new AccessDeniedException("Access denied");
        }

        private bool IsResultReady(string status)
        {
            return status == ResultReady;
        }
    }
}