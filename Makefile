PROJECT_NAME=PuWoPyoneer
ADDIN_NAME=PuWoGenerator
BUILD_DIR=build
ADDIN_PATH=$(APPDATA)/Autodesk/Revit/Addins/2024

all: build install

build:
	MSbuild.exe $(PROJECT_NAME)/$(ADDIN_NAME).csproj /p:Configuration=Debug /p:OutputPath=$(BUILD_DIR)

clean:
	MSbuild.exe $(PROJECT_NAME)/$(ADDIN_NAME).csproj /target:Clean

install:
	copy $(BUILD_DIR)\$(PROJECT_NAME)\$(ADDIN_NAME).dll "$(ADDIN_PATH)"

run:
	"C:/Program Files/Autodesk/Revit 2024/Revit.exe" /language DEU /nosplash
