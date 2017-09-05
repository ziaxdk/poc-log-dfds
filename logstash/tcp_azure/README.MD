# Azure

## multiple instances

### udp.conf local->forwarder

```
$ docker run -v //C/src/poc-log-dfds/logstash/tcp_azure/multiple/pipeline_1/:/usr/share/logstash/pipeline/ -v //C/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls-tcp_1 --rm -it docker.elastic.co/logstash/logstash:5.5.2
```

### udp.conf forwarder->elasticsearch

```
$ docker run -v //home/keols/poc-log-dfds/logstash/tcp_azure/multiple/pipeline_2/:/usr/share/logstash/pipeline/ -v //home/keols/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml -v //home/keols/poc-log-dfds/logstash/tcp_azure/multiple/template/custom_template.json:/usr/share/logstash/config/custom_template.json --name ls-tcp_2 --link es:elasticsearch -d -p 8080:8080 docker.elastic.co/logstash/logstash:5.5.2
```

