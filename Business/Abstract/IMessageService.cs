using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetInboxList();
        List<Message> GetSendboxList();
        List<Message> GetDraftList();
        List<Message> GetReadList();
        List<Message> GetUnReadList();
        List<Message> GetTrashList();
        Message GetByMessageId(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
