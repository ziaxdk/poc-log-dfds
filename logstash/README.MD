## Run

```
$ docker run -v //E/src/es/logstash/pipelines/:/usr/share/logstash/pipeline/ -v //E/src/es/logstash/settings/logstash.yml:/usr/share/logstash/config/logstash.yml --name ls --rm -it -p 9600:9600 docker.elastic.co/logstash/logstash:5.5.2
```

## Pull images

```
`$ docker pull docker.elastic.co/logstash/logstash:5.5.2
```


