﻿using Entity.Concrate;
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
        List<Message> GetSendboxList();  // Gönderilen Mesajlar
        List<Message> GetDraftList();  // Taslak Mesajlar
        List<Message> GetReadInboxList();  // Gelen- Okunmuş Mesajlar
        List<Message> GetUnReadInboxList();  // Gelen - Okunmamış Mesajlar
        List<Message> GetTrashList();  // Silinen mesajlar
        Message GetByMessageId(int id);
        void Add(Message message);  //Mesaj Ekle
        void Update(Message message);  // Mesaj Güncelle
        void Delete(Message message); // Mesaj Sil
    }
}
