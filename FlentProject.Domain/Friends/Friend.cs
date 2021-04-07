using CoreProject.Core.ValueObjects;
using FLentProject.Domain.Base.People;

namespace FLentProject.Domain.Friends
{
    public class Friend : Person
    {
        public const int MaxNickNameLength = 40;

        public string NickName { get; private set; }
        public Email Email { get; private set; }
        public Phone PhoneNumber01 { get; private set; }

        public Friend(string name, string nickName, Email email, Phone phoneNumber01) : base(name)
        {
            NickName = nickName;
            Email = email;
            PhoneNumber01 = phoneNumber01;
        }
    }
}
