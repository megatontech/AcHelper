using System;
using System.Collections.Generic;

namespace Article.model
{
    internal class Mail
    {
        private String status;

        private String info;

        private List<string> datas;

        public void setStatus(String status)
        {
            this.status = status;
        }

        public String getStatus()
        {
            return this.status;
        }

        public void setInfo(String info)
        {
            this.info = info;
        }

        public String getInfo()
        {
            return this.info;
        }

        public void setData(List<string> data)
        {
            this.datas = data;
        }

        public List<string> getData()
        {
            return this.datas;
        }
    }
}