using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Base.People;

namespace FLentProject.Domain.Friends
{
    public class Friend : Person
    {
        public const int MaxNickNameLength = 40;

        public string NickName { get; }
        public Email Email { get; }
        public Phone PhoneNumber01 { get; }

        public Friend(string name, string nickName, Email email, Phone phoneNumber01) : base(name)
        {
            NickName = nickName;
            Email = email;
            PhoneNumber01 = phoneNumber01;
        }
    }
}
