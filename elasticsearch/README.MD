## Run command

### Local PC

```
$ docker run -d -p 9200:9200 -v //E/src/poc-log-dfds/elasticsearch/elasticsearch.yml:/usr/share/elasticsearch/config/elasticsearch.yml --name es docker.elastic.co/elasticsearch/elasticsearch:5.5.2
```

### Azure

```
$ sudo sysctl -w vm.max_map_count=262144 # or add to /etc/sysctl.conf
$ docker run -d -p 9200:9200 -v /home/keols/poc-log-dfds/elasticsearch/elasticsearch_azure.yml:/usr/share/elasticsearch/config/elasticsearch.yml --name es docker.elastic.co/elasticsearch/elasticsearch:5.5.2
```

## Follow logs

```
$ docker logs -f es
```

## Pull images

```
$ docker pull docker.elastic.co/elasticsearch/elasticsearch:5.5.2
```

## ES commands

### List all indices

```
$ http://localhost:9200/_cat/indices?v
```

