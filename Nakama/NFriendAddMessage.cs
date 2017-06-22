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
using System.Collections.Generic;
using Google.Protobuf;

namespace Nakama
{
    public class NFriendAddMessage : INCollatedMessage<bool>
    {
        private Envelope payload;
        public IMessage Payload {
            get {
                return payload;
            }
        }

        private NFriendAddMessage(byte[] id)
        {
            payload = new Envelope {FriendsAdd = new TFriendsAdd { Friends =
            {
                new List<TFriendsAdd.Types.FriendsAdd>
                {
                    new TFriendsAdd.Types.FriendsAdd {UserId = ByteString.CopyFrom(id)}
                }
            }}};
        }
        
        private NFriendAddMessage(string handle)
        {
            payload = new Envelope {FriendsAdd = new TFriendsAdd { Friends =
            {
                new List<TFriendsAdd.Types.FriendsAdd>
                {
                    new TFriendsAdd.Types.FriendsAdd {Handle = handle}
                }
            }}};
        }

        public void SetCollationId(string id)
        {
            payload.CollationId = id;
        }

        public override string ToString()
        {
            var p = payload.FriendsAdd;
            string ids = "";
            string handles = "";
            foreach (var f in p.Friends)
            {
                switch (f.IdCase)
                {
                    case TFriendsAdd.Types.FriendsAdd.IdOneofCase.Handle:
                        handles += "handle=" + f.Handle + ",";
                        break;
                    case TFriendsAdd.Types.FriendsAdd.IdOneofCase.UserId:
                        ids += "id=" + f.UserId + ",";
                        break;
                }
            }
            return String.Format("NFriendsAddMessage(UserIds={0}, Handles={1})", ids, handles);
        }

        public static NFriendAddMessage Default(byte[] id)
        {
            return new NFriendAddMessage(id);
        }
        
        public static NFriendAddMessage Default(string handle)
        {
            return new NFriendAddMessage(handle);
        }
    }
}
