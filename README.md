# kafka

**Setup**
docker pull confluentinc/cp-zookeeper
docker pull confluentinc/cp-kafka
docker network create kafka
#copy network id

docker run -d --network=kafka --name=zookeeper -e ZOOKEEPER_CLIENT_PORT=2181 -e ZOOKEEPER_TICK_TIME=2000 -p 2181:2181 confluentinc/cp-zookeeper
docker logs zookeeper

docker run -d --network=kafka --name=kafka -p 9092:9092 -e KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181 -e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://localhost:9092 confluentinc/cp-kafka
docker logs kafka

**Nuget package**
Install-Package Confluent.Kafka -Version 1.8.2

**Kafka client**
https://www.conduktor.io/download/

**Nuget package for consumer**
Install-Package kafka-sharp -Version 1.4.3