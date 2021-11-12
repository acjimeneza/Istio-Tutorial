# Install_istio

## Download istioctl

Execute the next commands to install **istioclt**
```
cd ~
curl -L https://istio.io/downloadIstio | sh -
```
This will download and configure the PATH environment variable and add istioctl as a command in the terminal. If the command is not recognized, you need to add the path:
```
vim ~/.zshrc
or
vim ~/.bashrc
and add:
export PATH=$PATH:$HOME/istioctl-1.xx.xx/bin
```

## Install the istio CRD and Operator

Lets suppose that you had downloaded the versión istioctl-1.11.4. We need to execute the charts insisde de installation folder

```
cd ~/istioctl-1.11.4/manifest
```
Then execute the next command to create the **istio-system** namespace

```
kubectl create namespace istio-system
```

Create the istio base deployment:
```
helm install istio-base manifests/charts/base -n istio-system
```
After that deploy the istio service discovery **istiod** chart
```
helm install istiod manifests/charts/istio-control/istio-discovery \
    -n istio-system
```

Optional steps can be found in [Istio](https://istio.io/latest/docs/setup/install/helm/)


## Install Phometheus and Grafana

This next steps are only a base to configurate Prometheus and grafana.
Install Promehteus:
```
kubectl apply -f https://raw.githubusercontent.com/istio/istio/release-1.11/samples/addons/prometheus.yaml
```
Install grafana
```
https://istio.io/latest/docs/ops/integrations/grafana/
```
