﻿namespace Core6
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NServiceBus;
    using NServiceBus.MessageInterfaces;
    using NServiceBus.Serialization;
    using NServiceBus.Settings;

    class RegisterCustomSerializer
    {
        void Customize(EndpointConfiguration endpointConfiguration)
        {
            #region RegisterCustomSerializer

            endpointConfiguration.UseSerialization<MyCustomSerializerDefinition>();

            #endregion
        }

        #region CustomSerializer

        class MyCustomSerializerDefinition : SerializationDefinition
        {
            public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
            {
                return mapper => new MyCustomSerializer();
            }
        }

        class MyCustomSerializer : IMessageSerializer
        {
            public void Serialize(object message, Stream stream)
            {
                // Add code to serialize message
                throw new NotImplementedException();
            }

            public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
            {
                // Add code to deserialize message
                throw new NotImplementedException();
            }

            public string ContentType
            {
                get { throw new NotImplementedException(); }
            }
        }

        #endregion
    }
}