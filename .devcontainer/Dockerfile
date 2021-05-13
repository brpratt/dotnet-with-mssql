FROM mcr.microsoft.com/dotnet/sdk:5.0

# Whatever packages you want in your devcontainer
ARG PACKAGE_LIST="\
    ca-certificates \
    curl \
    file \
    git \
    iputils-ping \
    jq \
    lbzip2 \
    less \
    locales \
    lsb-release \
    make \
    man \
    manpages \
    manpages-dev \
    procps \
    ssh \
    sudo \
    vim \
    xz-utils"

# Install packages
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y upgrade --no-install-recommends \
    && apt-get -y install --no-install-recommends ${PACKAGE_LIST}

# Update locales for en_US.UTF-8
RUN sed -i -e 's/# en_US.UTF-8 UTF-8/en_US.UTF-8 UTF-8/' /etc/locale.gen && \
    dpkg-reconfigure --frontend=noninteractive locales && \
    update-locale LANG=en_US.UTF-8

# Create user
ARG USERNAME=coder
ARG USER_UID=1000
ARG USER_GID=$USER_UID
RUN groupadd --gid ${USER_GID} ${USERNAME} \
    && useradd -s /bin/bash --uid ${USER_UID} --gid ${USER_GID} -m ${USERNAME}

# Give user sudo permissions
RUN echo ${USERNAME} ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/${USERNAME} \
    && chmod 0440 /etc/sudoers.d/${USERNAME}

# Switch to user and configure terminal
USER $USERNAME
ARG TERM=xterm-256color
ENV TERM=${TERM}
