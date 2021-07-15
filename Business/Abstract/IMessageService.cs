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
        List<Message> GetInboxList(string mail);
        List<Message> GetSendboxList(string mail);  // Gönderilen Mesajlar
        List<Message> GetDraftList(string mail);  // Taslak Mesajlar
        List<Message> GetReadInboxList(string mail);  // Gelen- Okunmuş Mesajlar
        List<Message> GetUnReadInboxList(string mail);  // Gelen - Okunmamış Mesajlar
        List<Message> GetTrashList(string mail);  // Silinen mesajlar
        Message GetByMessageId(int id);
        void Add(Message message);  //Mesaj Ekle
        void Update(Message message);  // Mesaj Güncelle
        void Delete(Message message); // Mesaj Sil
    }
}
