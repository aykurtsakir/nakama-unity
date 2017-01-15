/**
 * Copyright 2017 The Nakama Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Google.Protobuf;

namespace Nakama
{
    public class NSelfFetchMessage : INMessage<INSelf>
    {
        private Envelope payload;
        public IMessage Payload {
            get {
                return payload;
            }
        }

        private NSelfFetchMessage()
        {
            payload = new Envelope {SelfFetch = new TSelfFetch()};
        }

        public void SetCollationId(string id)
        {
            payload.CollationId = id;
        }

        public override string ToString()
        {
            return "NSelfFetchMessage()";
        }

        public static NSelfFetchMessage Default()
        {
            return new NSelfFetchMessage.Builder().Build();
        }

        public class Builder
        {
            private NSelfFetchMessage message;

            public Builder()
            {
                message = new NSelfFetchMessage();
            }

            public NSelfFetchMessage Build()
            {
                // Clone object so builder now operates on new copy.
                var original = message;
                message = new NSelfFetchMessage();
                message.payload.SelfFetch = new TSelfFetch(original.payload.SelfFetch);
                return original;
            }
        }
    }
}