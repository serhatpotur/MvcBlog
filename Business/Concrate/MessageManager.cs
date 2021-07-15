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

        public List<Message> GetDraftList(string mail)
        {
            return _messageDal.List(x => x.isDraft == true && x.isTrash == false && x.SenderMail == mail);
        }

        public List<Message> GetInboxList(string mail)
        {
            return _messageDal.List(x => x.ReceiverMail == mail && x.isTrash == false);
        }

        public List<Message> GetReadInboxList(string mail)
        {
            return _messageDal.List(x => x.isRead == true && x.ReceiverMail == mail && x.isTrash == false && x.isDraft == false);
        }

        public List<Message> GetSendboxList(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail && x.isDraft == false);
        }

        public List<Message> GetTrashList(string mail)
        {
            return _messageDal.List(x => x.isTrash == true && x.isDraft == false && x.ReceiverMail == mail);
        }

        public List<Message> GetUnReadInboxList(string mail)
        {
            return _messageDal.List(x => x.isRead == false && x.ReceiverMail == mail && x.isTrash == false && x.isDraft == false);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
