﻿using System;
using NServiceBus;
using NServiceBus.Features;

public class SecondLevelRetriesConfig
{
    public void Simple()
    {
        #region SecondLevelRetriesDisableV5

        Configure.With(b => b.DisableFeature<SecondLevelRetries>());

        #endregion

        #region SecondLevelRetriesCustomPolicyV5

        Configure.With(b => b.SecondLevelRetries().CustomRetryPolicy(MyCustomRetryPolicy));

        #endregion
    }

    #region SecondLevelRetriesCustomPolicyHandlerV5
    TimeSpan MyCustomRetryPolicy(TransportMessage message)
    {
        // retry max 3 times
        if (GetNumberOfRetries(message) >= 3)
        {
            // sending back a TimeSpan.MinValue tells the 
            // SecondLevelRetry not to retry this message
            return TimeSpan.MinValue;
        }

        return TimeSpan.FromSeconds(5);
    }
    #endregion

    public static int GetNumberOfRetries(TransportMessage message)
    {
        string value;
        if (message.Headers.TryGetValue(Headers.Retries, out value))
        {
            int i;
            if (int.TryParse(value, out i))
            {
                return i;
            }
        }
        return 0;
    }
}