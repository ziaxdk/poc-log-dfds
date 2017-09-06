# Version 5.5.2 of ELK

### Memory must be at least 4GB in Docker for Windows

## Steps

- ES
- LS
- KB

## Demo

### Azure machine

```
$ docker run -d -p 9200:9200 -v /home/keols/poc-log-dfds/elasticsearch/elasticsearch_azure.yml:/usr/share/elasticsearch/config/elasticsearch.yml --name es docker.elastic.co/elasticsearch/elasticsearch:5.5.2
$ docker run -d -v //home/keols/poc-log-dfds/kibana/settings/kibana_azure.yml:/usr/share/kibana/config/kibana.yml --link es:elasticsearch --name kb -p 80:5601 docker.elastic.co/kibana/kibana:5.5.2
$ docker run -v //home/keols/poc-log-dfds/logstash/tcp_azure/multiple/pipeline_2/:/usr/share/logstash/pipeline/ -v //home/keols/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml -v //home/keols/poc-log-dfds/logstash/tcp_azure/multiple/template/custom_template.json:/usr/share/logstash/config/custom_template.json --name ls-tcp_2 --link es:elasticsearch -d -p 8080:8080 docker.elastic.co/logstash/logstash:5.5.2
```

### Local

```
$ docker run -v //E/src/poc-log-dfds/logstash/tcp_azure/multiple/pipeline_1/:/usr/share/logstash/pipeline/ -v //E/src/poc-log-dfds/logstash/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls-tcp_1 -p 9000:9000/udp --rm -it docker.elastic.co/logstash/logstash:5.5.2
$ run app.exe
```
