using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public Message GetByMessageId(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetDraftList()
        {
            return _messageDal.List(x => x.isDraft == true && x.isTrash == false);
        }

        public List<Message> GetInboxList()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.isTrash == false);
        }

        public List<Message> GetReadInboxList()
        {
            return _messageDal.List(x => x.isRead == true && x.ReceiverMail == "admin@gmail.com" && x.isTrash == false && x.isDraft == false);
        }

        public List<Message> GetSendboxList()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.isDraft == false);
        }

        public List<Message> GetTrashList()
        {
            return _messageDal.List(x => x.isTrash == true && x.isDraft == false);
        }

        public List<Message> GetUnReadInboxList()
        {
            return _messageDal.List(x => x.isRead == false && x.ReceiverMail == "admin@gmail.com" && x.isTrash == false && x.isDraft == false);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
