##日志配置：
1、执行WebApp下的db.sql创建mysql数据库，如果只测试Logstash可以不安装数据库

2、修改WebApp下的nlog.config文件type为Network的节点的Logstash接受地址

3、在Logstash主机上添加如下配置，重启Logstash
> input {   tcp {
>     port => 8102   } }
> filter{   json {
>     source => "message"   }
>   date {
>     match => [ "start", "yyyy/MM/dd HH:mm:ss" ]   }
>   mutate{
>     convert => {
>       "statusCode" => "integer"
>       "interval" => "integer"
>       "port" => "integer"
>     }   }
> }
> output {   elasticsearch {
>     hosts => "localhost:9200"
>     index => "core-%{+YYYY.MM.dd}"    } }


4、运行程序后即可在kibana看到日志


