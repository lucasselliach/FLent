using System;
using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Friends;
using Xunit;

namespace FLentProject.Domain.Test.FriendTests
{
    public class FriendTest
    {
        public class GameTest
        {
            [Fact]
            public void If_friend_has_been_created_then_friend_id_is_a_valid_guid()
            {
                var email = new Email("duduzinho@gmail.com");
                var phone = new Phone("9999999999");

                var friend = new Friend("duduzinho",
                                        "dudu",
                                        email,
                                        phone);

                Assert.True(Guid.TryParse(friend.Id, out _), "Friend id is not valid!");
            }
        }
    }
}
