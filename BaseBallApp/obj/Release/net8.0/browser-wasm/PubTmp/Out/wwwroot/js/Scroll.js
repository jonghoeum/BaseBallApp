window.scrollHandler = {
    init: function (elementId) {
        setTimeout(() => {
            const element = document.getElementById(elementId);
            if (!element) {
                console.warn("Element not found:", elementId);
                return;
            }

            // 기존 이벤트 제거 (중복 방지)
            window.removeEventListener("scroll", scrollHandler.scrollFunc);
            scrollHandler.scrollFunc = function () {
                const scrollY = window.scrollY || document.documentElement.scrollTop;
                if (scrollY > 100) {
                    element.classList.add("fixed");
                } else {
                    element.classList.remove("fixed");
                }
            };

            window.addEventListener("scroll", scrollHandler.scrollFunc);
        }, 100); // 100ms 지연 (필요 시 늘릴 수 있음)
    },
    scrollFunc: null
};