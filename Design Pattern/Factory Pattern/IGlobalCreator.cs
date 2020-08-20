using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.Factory_Pattern
{
    public interface IHumanCreator
    {
        string Create();
    }


    public class CreateMan : IHumanCreator
    {
        public string Create()
        {
            return "Man created";
        }
    }

    public class CreateWoman : IHumanCreator
    {
        public string Create()
        {
            return "Woman created";
        }
    }

    interface CreateHuman
    {
        IHumanCreator create();
    }

    public class ManFactory : CreateHuman
    {
        public IHumanCreator create()
        {
            return new CreateMan();
        }
    }


    public class WomanFactory : CreateHuman
    {
        public IHumanCreator create()
        {
            return new CreateWoman();
        }
    }

}
