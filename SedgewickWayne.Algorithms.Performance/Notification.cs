namespace SedgewickWayne.Algorithms.Performance
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public abstract class Notification
    {
    }

    public class TaskNotification : Notification, ICompletable
    {
        public void Complete()
        {
            throw new NotImplementedException(nameof(Complete));
        }
    }

    public interface ICompletable
    {
        void Complete();
    }

    public class AuthorisationNotification : Notification, IApprovable, IRejectable
    {
        public void Approve()
        {
            throw new NotImplementedException(nameof(Approve));
        }

        public void Reject(string reason)
        {
            throw new NotImplementedException(nameof(Reject));
        }
    }

    public interface IApprovable
    {
        void Approve();
    }

    public interface IRejectable
    {
        void Reject(string reason);
    }
}
