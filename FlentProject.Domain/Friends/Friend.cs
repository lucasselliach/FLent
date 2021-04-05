using CoreProject.Core.ValueObjects;
using FlentProject.Domain.Base.People;

namespace FlentProject.Domain.Friends
{
    public class Friend : Person
    {
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
