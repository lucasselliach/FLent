using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Friends;
using FLentProject.Domain.Friends.FriendValidations;
using Xunit;

namespace FLentProject.Domain.Test.FriendTests
{
    public class FriendValidationTest
    {
        [Fact]
        public void If_validation_has_been_checked_with_invalid_friend_then_friend_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend(null,
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Friend is not invalid!");
        }
        
        [Fact]
        public void If_validation_has_been_checked_with_valid_friend_then_friend_is_valid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.True(friendValidation.Check(friend), "Friend is not valid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_friend_name_then_name_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend(null,
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Null friend name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_friend_name_then_name_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Empty friend name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_min_lenght_enough_friend_name_then_name_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("du",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Min friend name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_friend_name_then_name_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinhouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Max friend name is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_friend_nickname_then_nickname_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                null,
                email,
                phone);

            Assert.False(friendValidation.Check(friend), "Null friend nickname is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_friend_nickname_then_nickname_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "duduaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                email,
                phone);

            Assert.False(friendValidation.Check(friend), "Max friend nickname is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_friend_email_then_email_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email(null);
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Null friend email is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_friend_email_then_email_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Empty friend email is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_friend_email_then_email_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm@mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Max friend email is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_friend_email_then_email_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("zezinho.com");
            var phone = new Phone("9999999999");

            var friend = new Friend("duduzinho",
                "dudu",
                email,
                phone);

            Assert.False(friendValidation.Check(friend), "Friend email is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_null_friend_phone_then_phone_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone(null);

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Null friend phone is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_empty_friend_phone_then_phone_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Empty friend phone is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_min_lenght_enough_friend_phone_then_phone_is_invalid()
        {
            var friendValidation = new FriendValidation();
            
            var email = new Email("duduzinho@gmail.com"); 
            var phone = new Phone("99999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Max friend phone is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_max_lenght_enough_friend_phone_then_phone_is_invalid()
        {
            var friendValidation = new FriendValidation();
            
            var email = new Email("duduzinho@gmail.com"); 
            var phone = new Phone("999999999999999999999999999999999999");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Max friend phone is not invalid!");
        }

        [Fact]
        public void If_validation_has_been_checked_with_invalid_friend_phone_then_phone_is_invalid()
        {
            var friendValidation = new FriendValidation();

            var email = new Email("duduzinho@gmail.com");
            var phone = new Phone("kkkkkk");

            var friend = new Friend("duduzinho",
                                    "dudu",
                                    email,
                                    phone);

            Assert.False(friendValidation.Check(friend), "Friend phone is not invalid!");
        }
    }
}
